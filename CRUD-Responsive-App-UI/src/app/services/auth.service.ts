import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';

const AUTH_API = 'http://localhost:18076/api/Account/';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
};

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  public isAuthenticated = new BehaviorSubject<boolean>(false);
  constructor(private http: HttpClient) {}

  login(credentials): Observable<any> {
    let url = `${AUTH_API}signIn`;
    return this.http.post(
      url,
      {
        Username: credentials.username,
        Password: credentials.password,
      },
      httpOptions
    );
  }
}
