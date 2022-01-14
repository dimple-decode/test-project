import { User } from "./../model/user.model";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

const USER_API_URL = "http://localhost:18076/api/User/";
const httpOptions = {
  headers: new HttpHeaders({ "Content-Type": "application/json" }),
};

@Injectable({
  providedIn: "root",
})
export class UserService {
  constructor(private http: HttpClient) {}

  getUsers(): Observable<any> {
    let url = `${USER_API_URL}GetUsers`;
    return this.http.get(url);
  }

  getUser(id: string): Observable<any> {
    let url = `${USER_API_URL}GetUser/${id}`;
    return this.http.get(url);
  }

  createUser(userModel: User): Observable<any> {
    let url = `${USER_API_URL}AddUser`;

    return this.http.post(url, userModel);
  }

  updateUser(id: string, userModel: User): Observable<any> {
    let url = `${USER_API_URL}EditUser/${id}`;
    return this.http.put(url, userModel);
  }

  deleteUser(id: string): Observable<any> {
    let url = `${USER_API_URL}Delete/${id}`;
    return this.http.delete(url);
  }
}
