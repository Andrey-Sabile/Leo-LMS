import { Component, OnInit, inject } from '@angular/core';
import {
  TodoListsClient, TodoItemsClient,
  TodoListDto, TodoItemDto, LookupDto,
  CreateTodoListCommand, UpdateTodoListCommand,
  CreateTodoItemCommand, UpdateTodoItemCommand
} from '@app/data-access/api/api-client';
import { JsonPipe } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-todo-component',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.css'],
  standalone: true,
  imports: [FormsModule, JsonPipe]
})
export class TodoComponent implements OnInit {
  private listsClient = inject(TodoListsClient);
  private itemsClient = inject(TodoItemsClient);

  debug = false;
  isLoading = true;
  lists: TodoListDto[] = [];
  priorityLevels: LookupDto[] = [];
  selectedList: TodoListDto | null = null;
  selectedItem: TodoItemDto | null = null;

  /** Inserted by Angular inject() migration for backwards compatibility */
  constructor(...args: unknown[]);

  constructor() { }

  ngOnInit(): void {
    this.listsClient.getTodoLists().subscribe(
      result => {
        this.lists = result.lists;
        this.priorityLevels = result.priorityLevels;
        if (this.lists.length) {
          this.selectedList = this.lists[0];
        }
        this.isLoading = false;
      },
      error => {
        console.error(error);
        this.isLoading = false;
      }
    );
  }

  // Lists
  remainingItems(list: TodoListDto): number {
    return list.items.filter(t => !t.done).length;
  }

  addList(): void {
    const title = prompt('List title...');

    if (!title?.trim()) {
      return;
    }

    const trimmedTitle = title.trim();

    const list = {
      id: 0,
      title: trimmedTitle,
      items: []
    } as TodoListDto;

    this.listsClient.createTodoList(list as CreateTodoListCommand).subscribe(
      result => {
        list.id = result;
        this.lists.push(list);
        this.selectedList = list;
      },
      error => console.error(error)
    );
  }

  renameSelectedList(): void {
    const selectedList = this.selectedList;

    if (!selectedList) {
      return;
    }

    const title = prompt('Update list title...', selectedList.title);

    if (!title?.trim() || title.trim() === selectedList.title) {
      return;
    }

    const updated = { id: selectedList.id, title: title.trim() } as UpdateTodoListCommand;

    this.listsClient.updateTodoList(selectedList.id, updated).subscribe(
      () => {
        if (this.selectedList && this.selectedList.id === selectedList.id) {
          this.selectedList.title = updated.title;
        }
      },
      error => console.error(error)
    );
  }

  deleteSelectedList(): void {
    const selectedList = this.selectedList;

    if (!selectedList) {
      return;
    }

    const confirmed = confirm(`Delete "${selectedList.title}" and all items?`);

    if (!confirmed) {
      return;
    }

    const listId = selectedList.id;

    this.listsClient.deleteTodoList(listId).subscribe(
      () => {
        this.lists = this.lists.filter(t => t.id !== listId);
        this.selectedList = this.lists.length ? this.lists[0] : null;
      },
      error => console.error(error)
    );
  }

  addItem() {
    if (!this.selectedList) {
      return;
    }

    const item = {
      id: 0,
      listId: this.selectedList.id,
      priority: this.priorityLevels.length ? this.priorityLevels[0].id : 0,
      title: '',
      done: false
    } as TodoItemDto;

    this.selectedList.items.push(item);
    const index = this.selectedList.items.length - 1;
    this.editItem(item, 'itemTitle' + index);
  }

  editItem(item: TodoItemDto, inputId: string): void {
    this.selectedItem = item;
    setTimeout(() => document.getElementById(inputId)?.focus(), 100);
  }

  updateItem(item: TodoItemDto, pressedEnter: boolean = false): void {
    if (!this.selectedList) {
      return;
    }

    const isNewItem = item.id === 0;

    if (!item.title.trim()) {
      this.deleteItem(item);
      return;
    }

    if (item.id === 0) {
      this.itemsClient
        .createTodoItem({ title: item.title, listId: this.selectedList.id } as CreateTodoItemCommand)
        .subscribe(
          result => {
            item.id = result;
          },
          error => console.error(error)
        );
    } else {
      this.itemsClient.updateTodoItem(item.id, item as UpdateTodoItemCommand).subscribe(
        () => console.log('Update succeeded.'),
        error => console.error(error)
      );
    }

    this.selectedItem = null;

    if (isNewItem && pressedEnter) {
      setTimeout(() => this.addItem(), 250);
    }
  }

  deleteItem(item: TodoItemDto) {
    const selectedList = this.selectedList;

    if (!selectedList) {
      return;
    }

    if (item.id === 0) {
      const index = selectedList.items.indexOf(item);
      if (index > -1) {
        selectedList.items.splice(index, 1);
      }
    } else {
      this.itemsClient.deleteTodoItem(item.id).subscribe(
        () =>
          (selectedList.items = selectedList.items.filter(t => t.id !== item.id)),
        error => console.error(error)
      );
    }
  }
}
