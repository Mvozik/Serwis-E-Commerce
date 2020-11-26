import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { CategoryModel } from '../../../admin-panel/models/category.model';
import { ProductModel } from '../../../admin-panel/models/product.model';
import { CategoryService } from '../../../admin-panel/services/category.service';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {

  constructor(private route: ActivatedRoute , private productService:ProductService,private categoryService:CategoryService ) { 
    
    
    const id: Observable<string> = this.route.params.pipe(map(p => p.id));
    id.subscribe(response=>{
      this.productService.getProductsBySectionId(parseInt(response)).subscribe(response=> this.products=response);
      this.categoryService.getCategoriesBySectionId(parseInt(response)).subscribe(response=>this.categories=response);
    });
    
  }
  products:ProductModel[];
  categories:CategoryModel[];
  ngOnInit(): void {
    
  }

}
