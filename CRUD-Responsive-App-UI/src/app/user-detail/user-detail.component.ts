import { DocumentModel } from './../model/document.model';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from './../services/user.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { User } from '../model/user.model';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css'],
})
export class UserDetailComponent implements OnInit {
  form: FormGroup;
  userId: string;
  formHeading: string;
  enableSubmitBtn: boolean = true;
  document: DocumentModel;
  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.initializeForm();

    this.route.params.subscribe((res) => {
      this.userId = res['id'];
      this.enableSubmitBtn = res['action'] != 'View' ? true : false;
      if (this.userId) {
        this.formHeading = 'User Detail';
        this.userService.getUser(this.userId).subscribe((x) => {
          this.form.setValue(x);
        });
      } else {
        this.formHeading = 'Add User';
      }
    });
  }

  initializeForm() {
    this.form = this.fb.group({
      id: [''],
      firstName: ['', [Validators.required, Validators.maxLength(50)]],
      lastName: ['', [Validators.required, Validators.maxLength(50)]],
      dateOfBirth: ['', [Validators.required]],
      fileName: ['', Validators.required],
      document: [null],
    });
  }

  onSubmit() {
    if (this.form.invalid) return;
    if (this.form.value.id) {
      this.userService.updateUser(this.userId, this.form.value).subscribe(
        (res) => {
          alert('User updated succesfully.');
          this.router.navigate(['user-listing']);
        },
        (err) => {
          alert('Unable to modify user');
        }
      );
    } else {
      this.userService.createUser(this.form.value).subscribe(
        (res) => {
          alert('User created succesfully.');
          this.router.navigate(['user-listing']);
        },
        (err) => {
          alert('Unable to create user');
        }
      );
    }
  }

  onFileSelect(event: any) {
    if (event.target.files && event.target.files.length) {
      let documentObject: DocumentModel = new DocumentModel();
      const file: File = event.target.files[0];

      if (this.form.value.document && this.form.value.document.documentId) {
        documentObject.documentId = this.form.value.document.documentId;
      }
      documentObject.documentName = file.name;
      documentObject.documentSize = file.size;
      documentObject.documentType = file.type;
      const reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onload = function (e: any) {
        documentObject.documentData = e.target.result.toString().split(',')[1];
        this.form.value.document = { ...documentObject };
        console.log(this.form.value.document);
      }.bind(this);
    }
  }
}
