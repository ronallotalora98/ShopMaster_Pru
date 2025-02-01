import { Component, OnInit } from '@angular/core';
import { TopBarComponent } from '../../components/top-bar/top-bar.component';
import { SidebarComponent } from '../../components/sidebar/sidebar.component';
import { RouterOutlet } from '@angular/router';
import { FooterComponent } from '../../components/footer/footer.component';

@Component({
  selector: 'app-layout-page',
  standalone: true,
  templateUrl: './layout-page.component.html',
  imports:[TopBarComponent, SidebarComponent, FooterComponent, RouterOutlet],
  styleUrls: ['./layout-page.component.scss']
})
export class LayoutPageComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  public onToggleMobileMenu(): void {
    const currentSIdebarSize =
      document.documentElement.getAttribute('data-sidebar-size');

    if (document.documentElement.clientWidth >= 767) {
      if (currentSIdebarSize == null) {
        document.documentElement.getAttribute('data-sidebar-size') == null ||
        document.documentElement.getAttribute('data-sidebar-size') == 'lg'
          ? document.documentElement.setAttribute('data-sidebar-size', 'sm')
          : document.documentElement.setAttribute('data-sidebar-size', 'lg');
      } else if (currentSIdebarSize == 'md') {
        document.documentElement.getAttribute('data-sidebar-size') == 'md'
          ? document.documentElement.setAttribute('data-sidebar-size', 'sm')
          : document.documentElement.setAttribute('data-sidebar-size', 'md');
      } else {
        document.documentElement.getAttribute('data-sidebar-size') == 'sm'
          ? document.documentElement.setAttribute('data-sidebar-size', 'lg')
          : document.documentElement.setAttribute('data-sidebar-size', 'sm');
      }
    }

    if (document.documentElement.clientWidth <= 767) {
      document.body.classList.toggle('vertical-sidebar-enable');
    }
  }
}
