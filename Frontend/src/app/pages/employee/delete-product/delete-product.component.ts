import { Component, OnInit } from '@angular/core';
import { cilCheckAlt, cilX } from '@coreui/icons';
import { ProductService } from '../../../services/product.service';
import { Product } from '../../../interfaces/product';
import { CommonService } from '../../../services/CommonService';

@Component({
  selector: 'app-delete-product',
  templateUrl: './delete-product.component.html',
  styleUrls: ['./delete-product.component.css'],
})
export class DeleteProductComponent implements OnInit {
  products: Product[] = [];
  icons = { cilCheckAlt, cilX };
  targetItem: any = undefined;
  visible = false;
  modalTitle = '';
  modalMessage = '';

  constructor(
    private commonService: CommonService,
    private productService: ProductService
  ) {}

  ngOnInit(): void {
    this.getProductsByUser();
  }

  getProductsByUser() {
    this.productService.getProductsByUser().subscribe((p: any) => (this.products = p));
  }

  deleteProduct(index: number): void {
    for (let product of this.products) {
      if (product.id === index) {
        this.targetItem = product;
        break;
      }
    }
    if (this.targetItem) {
      this.modalTitle = 'Delete Product';
      this.modalMessage = `Deleting '${this.targetItem.code} - ${this.targetItem.name}'. Are you sure ?`;
      this.visible = true;
    }
  }

  closeModal(): void {
    this.visible = false;
  }

  saveModal(event: any): void {
    if (event) {
      this.productService.deleteProduct(this.targetItem.id).subscribe((p: any) => {
        if (p) {
          this.visible = false;
          this.getProductsByUser();
          this.commonService.updateToastData(
            `Success deleting product "${this.targetItem.code} - ${this.targetItem.name}"`,
            'success',
            'Product deleted.'
          );
        }
      });
    }
  }
}
