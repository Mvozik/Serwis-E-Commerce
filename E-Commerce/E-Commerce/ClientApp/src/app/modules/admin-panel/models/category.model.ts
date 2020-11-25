import { SubCategoryModel } from "./sub-category.model";

export interface CategoryModel
{
    id:number;
    name:string;
    sectionId:number;
    subCategories:SubCategoryModel[];
}