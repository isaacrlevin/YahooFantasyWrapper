import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserService } from './../../shared/user.service';
import { LoadingService } from './../../shared/index';
@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html'
})
export class NavMenuComponent {
  isExpanded = false;
  loginUrl: string;

  constructor(http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    public userService: UserService,
    public loadingService: LoadingService) {
    http.get<string>(baseUrl + 'api/Account/Login', { responseType: 'text' as 'json' }).subscribe(result => {
      this.loginUrl = result;
    }, error => console.error(error));
  }

  logout() {
    this.userService.setUser(null);
  }


  login() {
    window.location.href = this.loginUrl;
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
