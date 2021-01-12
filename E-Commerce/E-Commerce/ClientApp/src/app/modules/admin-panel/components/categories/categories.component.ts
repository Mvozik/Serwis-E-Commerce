import { KeyValue } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { consts } from '../../../../CONST';
import { AddCategoryModel } from '../../models/add-category.model';
import { AddSubCategoryModel } from '../../models/add-subcategory.model';
import { CategoryModel } from '../../models/category.model';
import { CategoryService } from '../../services/category.service';
@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.scss'],
})
export class CategoriesComponent implements OnInit {
  constructor(
    private categoryService: CategoryService,
    private _snackBar: MatSnackBar
  ) {
    this.sectionForm = new FormGroup({
      name: new FormControl('', Validators.required),
    });

    this.categoryForm = new FormGroup({
      name: new FormControl('', Validators.required),
      sectionId: new FormControl(0, Validators.required),
    });

    this.subCategoryForm = new FormGroup({
      name: new FormControl('', Validators.required),
      categoryId: new FormControl(0, Validators.required),
    });
    this.categoryService
      .getCategories()
      .subscribe((response) => (this.categories = response));
  }
  sections = consts.sections;
  categories: CategoryModel[];
  sectionForm: FormGroup;
  categoryForm: FormGroup;
  subCategoryForm: FormGroup;
  ngOnInit(): void {}
  addSection() {}
  addCategory() {
    let model: AddCategoryModel = {
      name: this.categoryForm.get('name').value,
      sectionId: this.categoryForm.get('sectionId').value,
    };

    this.categoryService.postCategory(model).subscribe((response) => {
      this._snackBar.open(
        'Kategoria ' + response.name + ' została dodana',
        '',
        {
          duration: 2000,
        }
      );
    });
  }
  addSubCategory() {
    let model: AddSubCategoryModel = {
      name: this.subCategoryForm.get('name').value,
      categoryId: this.subCategoryForm.get('categoryId').value,
    };

    this.categoryService.postSubCategory(model).subscribe((response) => {
      this._snackBar.open(
        'Podkategoria ' + response.name + ' została dodana',
        '',
        {
          duration: 2000,
        }
      );
    });
  }

  changeSectionSelect(event: any) {
    this.categoryForm.patchValue({ sectionId: event.value });
  }
  changeCategorySelect(event: any) {
    this.subCategoryForm.patchValue({ categoryId: event.value });
  }
}
