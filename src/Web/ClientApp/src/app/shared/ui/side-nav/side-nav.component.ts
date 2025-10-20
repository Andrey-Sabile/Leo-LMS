import { Component } from '@angular/core';
import { NgFor } from '@angular/common';
import { RouterLink, RouterLinkActive } from '@angular/router';

type NavLink = {
  label: string;
  route: string;
  exact?: boolean;
  iconPaths: readonly string[];
};

@Component({
  selector: 'app-side-nav',
  standalone: true,
  templateUrl: './side-nav.component.html',
  imports: [RouterLink, RouterLinkActive, NgFor]
})
export class SideNavComponent {
  protected readonly navLinks: readonly NavLink[] = [
    {
      label: 'Home',
      route: '/',
      exact: true,
      iconPaths: [
        'M3 10.353L12 3l9 7.353V19.5A1.5 1.5 0 0 1 19.5 21h-3A1.5 1.5 0 0 1 15 19.5V15a1.5 1.5 0 0 0-1.5-1.5h-3A1.5 1.5 0 0 0 9 15v4.5A1.5 1.5 0 0 1 7.5 21h-3A1.5 1.5 0 0 1 3 19.5z'
      ]
    },
    {
      label: 'Calendar',
      route: '/calendar',
      exact: true,
      iconPaths: [
        'M8 3v3.5',
        'M16 3v3.5',
        'M4.5 9h15',
        'M6 5h12a2 2 0 0 1 2 2v11a2 2 0 0 1-2 2H6a2 2 0 0 1-2-2V7a2 2 0 0 1 2-2z'
      ]
    },
    {
      label: 'Student Directory',
      route: '/student-directory',
      exact: true,
      iconPaths: [
        'M15 13a3 3 0 1 0-6 0a3 3 0 0 0 6 0z',
        'M5 19a7 7 0 0 1 14 0',
        'M6 8.5a3 3 0 1 0 0-6',
        'M18 8.5a3 3 0 1 0 0-6'
      ]
    },
    {
      label: 'Counter',
      route: '/counter',
      iconPaths: [
        'M6 9h12',
        'M6 15h12',
        'M9 6v12'
      ]
    },
    {
      label: 'Fetch Data',
      route: '/fetch-data',
      iconPaths: [
        'M4 6h16',
        'M4 12h16',
        'M4 18h16'
      ]
    }
  ];

}
