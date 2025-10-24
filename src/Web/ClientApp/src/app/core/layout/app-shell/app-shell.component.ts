import { Component } from '@angular/core';
import { RouterOutlet, RouterLink, RouterLinkActive } from '@angular/router';
import { provideIcons, NgIcon } from '@ng-icons/core';
import { heroHome, heroBookOpen, heroCalendar, heroListBullet, heroPhone } from '@ng-icons/heroicons/outline';

type NavLink = {
  label: string;
  route: string;
  exact?: boolean;
  iconPaths: string;
};

@Component({
  selector: 'app-shell',
  templateUrl: './app-shell.component.html',
  viewProviders: [provideIcons({ heroHome, heroBookOpen, heroCalendar, heroListBullet, heroPhone })],
  imports: [RouterOutlet, NgIcon, RouterLink, RouterLinkActive]
})
export class AppShellComponent {
  protected readonly navLinks: readonly NavLink[] = [
    {
      label: 'Home',
      route: '/',
      exact: true,
      iconPaths: 'heroHome'
    },
    {
      label: 'Classes',
      route: '/classes',
      iconPaths: 'heroBookOpen'

    },
    {
      label: 'Calendar',
      route: '/calendar',
      exact: true,
      iconPaths: 'heroCalendar'

    },
    {
      label: 'Student Directory',
      route: '/student-directory',
      exact: true,
      iconPaths: 'heroPhone'
    },
    {
      label: 'Todo',
      route: '/todo',
      iconPaths: 'heroListBullet'
    },

  ];
}
