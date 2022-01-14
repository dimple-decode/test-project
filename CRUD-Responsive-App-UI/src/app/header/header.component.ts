import { BehaviorSubject } from 'rxjs';
import { TokenStorageService } from './../services/token-storage.service';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  constructor(
    private router: Router,
    public tokenStorage: TokenStorageService
  ) {}

  ngOnInit(): void {}
  logOut() {
    localStorage.clear();
    this.router.navigate(['login']);
  }
}
