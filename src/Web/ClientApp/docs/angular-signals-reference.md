# 🧩 Angular Signals --- Component Usage Reference

A quick summary for using **Angular Signals** inside standalone
components.

------------------------------------------------------------------------

## 1. Create Signals (Reactive State)

Use `signal()` to declare reactive, mutable local state.

``` ts
readonly count = signal(0);
readonly items = signal<string[]>([]);
```

-   Acts like a `BehaviorSubject` but simpler and synchronous.
-   `count()` returns the value.
-   `count.set(newValue)` updates it.
-   `count.update(fn)` modifies based on the current value.

``` ts
this.count.update(c => c + 1);
```

------------------------------------------------------------------------

## 2. Derive State (Computed Signals)

Use `computed()` for derived or dependent values.

``` ts
readonly doubleCount = computed(() => this.count() * 2);
```

-   Automatically recalculates when dependencies change.
-   No manual subscription needed.

------------------------------------------------------------------------

## 3. React to Changes (Effects)

Use `effect()` to run side effects whenever dependent signals change.

``` ts
effect(() => {
  console.log('Count changed:', this.count());
});
```

-   Runs once immediately, then on every dependency change.
-   Ideal for logging, async calls, or syncing external systems.

------------------------------------------------------------------------

## 4. Use Signals in Templates

``` html
<p>Count: {{ count() }}</p>
<p>Doubled: {{ doubleCount() }}</p>
```

-   No need for `| async` pipe.
-   No need for `ChangeDetectorRef.markForCheck()`.

------------------------------------------------------------------------

## 5. Update State from Template

``` html
<button (click)="count.update(c => c + 1)">Increment</button>
```

Or via class methods:

``` ts
increment() {
  this.count.update(c => c + 1);
}
```

------------------------------------------------------------------------

## 6. Combine Signals with Async Data

``` ts
ngOnInit() {
  this.apiClient.getItems().subscribe({
    next: items => this.items.set(items),
  });
}
```

Now the rest of your component can react to `items()` as a signal.

------------------------------------------------------------------------

## 7. Computed vs Effect --- Key Differences

  -----------------------------------------------------------------------
  Concept           Purpose           Returns           Trigger
  ----------------- ----------------- ----------------- -----------------
  `signal()`        Holds reactive    Value             Manual updates
                    state                               

  `computed()`      Derives new       Derived signal    Dependencies
                    values                              change

  `effect()`        Runs side effects void              Dependencies
                                                        change
  -----------------------------------------------------------------------

------------------------------------------------------------------------

## 8. Example Component

``` ts
@Component({
  selector: 'app-counter',
  standalone: true,
  template: \`
    <h2>Count: {{ count() }}</h2>
    <h3>Double: {{ doubleCount() }}</h3>
    <button (click)="increment()">+1</button>
  \`,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CounterComponent {
  readonly count = signal(0);
  readonly doubleCount = computed(() => this.count() * 2);

  increment() {
    this.count.update(c => c + 1);
  }
}
```

------------------------------------------------------------------------

## ✅ When to Use Signals

Use **signals** for: - Local UI state (`viewMode`, `selectedItem`,
`filters`) - Derived values (`computed totals, labels, etc.`) -
Replacing simple `BehaviorSubject` logic - Reactive components without
NgRx or RxJS

Use **RxJS** for: - Async streams (HTTP, websockets) - Complex
transformations or debounced input handling

------------------------------------------------------------------------

*Keep this handy as a quick reference when building new Angular
components with Signals.*
