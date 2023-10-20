import { Component, OnInit } from '@angular/core';
import { cilCheckAlt, cilX, cilSync} from '@coreui/icons';
import { ProductService } from '../../../services/product.service';
import { Router } from "@angular/router";
import { Product } from '../../../interfaces/product';
import { CommonService } from '../../../services/CommonService';

@Component({
  selector: 'app-list-products',
  templateUrl: './list-products.component.html',
  styleUrls: ['./list-products.component.css'],
})
export class ListProductsComponent implements OnInit {
  products: Product[] = [];
  icons = { cilCheckAlt, cilX, cilSync};
  targetItem: any = undefined;
  visible = false;

  constructor(
    private commonService: CommonService,
    private route: Router,
    private productService: ProductService
  ) {}

  ngOnInit(): void {
    this.getProductsByUser();
  }

  getProductsByUser() {
    this.productService.getProductsByUser().subscribe((p: any) => (this.products = p));
  }

  updateProduct(id: number): void {
    this.route.navigate(['employee/update-product', 
        { id: id }])
  }
  
}
