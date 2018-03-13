import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { OnInit, Component, Inject } from '@angular/core';
import { LoginService } from './../../shared/login.service';
import { UserService } from './../../shared/user.service';
import { LoadingService } from './../../shared/index';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  constructor(private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private activatedRoute: ActivatedRoute,
    private loginService: LoginService,
    private router: Router,
    private userService: UserService,
    private loadingService: LoadingService) { }

  ngOnInit() {
    // subscribe to router event
    this.activatedRoute.queryParams.subscribe((params: Params) => {
      let code = params['code'];
      if (code != null) {
        this.loginService.login(code).subscribe(result => {
          this.userService.setUser(result);
          this.router.navigate(['/']);
        }, error => console.error(error));
      }
    });
  }
}
