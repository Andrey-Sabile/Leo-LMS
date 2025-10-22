import { Component } from '@angular/core';
import { NgIcon, provideIcons } from '@ng-icons/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { heroHome, heroBookOpen, heroCalendar, heroListBullet, heroPhone } from '@ng-icons/heroicons/outline';


type NavLink = {
  label: string;
  route: string;
  exact?: boolean;
  iconPaths: string;
};

@Component({
  selector: 'app-side-nav',
  standalone: true,
  templateUrl: './side-nav.component.html',
  imports: [RouterLink, RouterLinkActive, NgIcon],
  viewProviders: [provideIcons({ heroHome, heroBookOpen, heroCalendar, heroListBullet, heroPhone })]

})
export class SideNavComponent {
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
