import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavMenuComponent } from '@app/shared/ui/nav-menu/nav-menu.component';

@Component({
  selector: 'app-shell',
  standalone: true,
  templateUrl: './app-shell.component.html',
  imports: [NavMenuComponent, RouterOutlet]
})
export class AppShellComponent {}
