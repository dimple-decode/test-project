import { Router } from '@angular/router';
import { UserService } from './../services/user.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { User } from '../model/user.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { IUserElement } from './../model/IUserElement.interface';

@Component({
  selector: 'app-user-listing',
  templateUrl: './user-listing.component.html',
  styleUrls: ['./user-listing.component.css'],
})
export class UserListingComponent implements OnInit {
  displayedColumns: string[] = [
    'FirstName',
    'LastName',
    'DateOfBirth',
    'Action',
  ];
  dataSource = new MatTableDataSource<IUserElement>(null);
  //@ViewChild(MatPaginator) paginator: MatPaginator;

  users: Array<User>;
  constructor(private userService: UserService, private router: Router) {}

  ngOnInit(): void {
    //
    this.userService.getUsers().subscribe((res) => {
      this.users = res;
      this.users.forEach((x) => {
        x.Action = ['View', 'Edit', 'Delete'];
      });

      console.log(this.users);
      this.dataSource = new MatTableDataSource<IUserElement>(this.users);
    });
  }

  onBtnClick(actionType, userModel) {
    let id, route;
    if (actionType != 'Add') {
      id = userModel.id;
      route = `/user-detail/${actionType}/${id}`;
    }

    switch (actionType) {
      case 'Add':
        this.router.navigate(['user-detail']);
        break;
      case 'View':
        this.userService.getUser(userModel.id).subscribe((res) => {
          this.router.navigate([route]);
        });
        break;
      case 'Edit':
        this.router.navigate([route]);
        break;
      case 'Delete':
        this.userService.deleteUser(userModel.id).subscribe((res) => {
          alert('User successfully deleted.');
          window.location.reload();
        });
        break;
    }
  }
}
