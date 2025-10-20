import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavMenuComponent } from '@app/shared/ui/nav-menu/nav-menu.component';
import { SideNavComponent } from '@app/shared/ui/side-nav/side-nav.component';

@Component({
  selector: 'app-shell',
  standalone: true,
  templateUrl: './app-shell.component.html',
  imports: [NavMenuComponent, RouterOutlet, SideNavComponent]
})
export class AppShellComponent { }
