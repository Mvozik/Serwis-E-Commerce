import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthService } from 'src/app/services/auth.service';
import { UserInformationsModel } from '../../models/user-informations.model';

@Component({
  selector: 'app-user-options',
  templateUrl: './user-options.component.html',
  styleUrls: ['./user-options.component.scss'],
})
export class UserOptionsComponent implements OnInit {
  constructor(
    private _snackBar: MatSnackBar,
    private authService: AuthService,
    private formBuilder: FormBuilder
  ) {}
  userInfoForm: FormGroup;

  ngOnInit(): void {
    this.userInfoForm = this.formBuilder.group({
      id: ['', Validators.required],
      name: ['', Validators.required],
      surName: ['', Validators.required],
      city: ['', Validators.required],
      street: ['', Validators.required],
      buildingNumber: ['', Validators.required],
      flatNumber: [''],
      postCode: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      nip: [''],
    });

    this.authService.getUserInformations().subscribe((response) => {
      this.userInfoForm.patchValue({
        id: response.id,
        name: response.name,
        surName: response.surName,
        city: response.city,
        street: response.street,
        buildingNumber: response.buildingNumber,
        postCode: response.postCode,
        phoneNumber: response.phoneNumber,
        nip: response.nip,
        flatNumber: response.flatNumber,
      });
    });
  }

  putUserInfoForm() {
    if (this.userInfoForm.touched) {
      let model: UserInformationsModel = {
        id: this.userInfoForm.value.id,
        name: this.userInfoForm.value.name,
        surName: this.userInfoForm.value.surName,
        city: this.userInfoForm.value.city,
        street: this.userInfoForm.value.street,
        buildingNumber: this.userInfoForm.value.buildingNumber,
        flatNumber: this.userInfoForm.value.flatNumber,
        postCode: this.userInfoForm.value.postCode,
        phoneNumber: this.userInfoForm.value.phoneNumber,
        nip: this.userInfoForm.value.nip,
      };
      this.authService.putUserInformations(model).subscribe((response) =>
        this._snackBar.open('Twoje dane zostały pomyślnie zapisane', '', {
          duration: 2000,
        })
      );
    }
  }
}
