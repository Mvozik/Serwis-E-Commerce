export interface AddProductModel {
  name: string;
  price: number;
  quantity: number;
  description: string;
  specification: string;
  formFile: File;
  subCategoryId: number;
}
