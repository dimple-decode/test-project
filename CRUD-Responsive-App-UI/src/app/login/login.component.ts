import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { TokenStorageService } from '../services/token-storage.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  form: FormGroup;
  isLoggedIn = false;
  isLoginFailed = false;
  errorMessage = '';
  isAuthenticated: boolean;
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private authService: AuthService,
    private tokenStorage: TokenStorageService
  ) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      username: ['', Validators.email],
      password: ['', Validators.required],
    });

    if (this.tokenStorage.getToken()) {
      this.isLoggedIn = true;
    }
  }

  onSubmit() {
    if (this.form.invalid) return;
    this.authService.login(this.form.value).subscribe(
      (res) => {
        if (res && res.bearerToken) {
          this.tokenStorage.saveToken(res.bearerToken);
          this.isLoggedIn = true;
          this.router.navigate(['home']);
        } else {
          this.router.navigate(['unauthorized']);
        }
      },
      (err) => {
        this.isLoginFailed = true;
        this.router.navigate(['unauthorized']);
      }
    );
  }
}
