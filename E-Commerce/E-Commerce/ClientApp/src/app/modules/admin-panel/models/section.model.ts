import { CategoryModel } from "./category.model";

export interface SectionModel
{
    id:number;
    name:string;
    categories:CategoryModel[];
}