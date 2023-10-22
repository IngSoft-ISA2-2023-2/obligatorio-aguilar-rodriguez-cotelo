import { Component, OnInit } from "@angular/core";
import { AbstractControl, FormBuilder, FormControl, FormGroup } from "@angular/forms";
import { Pharmacy } from "src/app/interfaces/pharmacy";
import { Role } from "src/app/interfaces/role";
import { CommonService } from "src/app/services/CommonService";
import { ProductRequest } from 'src/app/interfaces/product';
import { ProductService } from "src/app/services/product.service";
import { PharmacyService } from "src/app/services/pharmacy.service";
import { RoleService } from "src/app/services/role.service";
import { cilShortText, cilPencil, cilSync } from '@coreui/icons';
import { ActivatedRoute, Router } from "@angular/router";
import { Product } from "src/app/interfaces/product";

@Component({
    selector: 'app-update-product',
    templateUrl: './update-product.component.html',
    styleUrls: ['./update-product.component.css'],
})

export class UpdateProductComponent implements OnInit {
    form: FormGroup | any;
    product: Product | any;

    icons = { cilShortText, cilPencil, cilSync }

    constructor(
        private fb: FormBuilder,
        private productService: ProductService,
        private commonService: CommonService,
        private route: ActivatedRoute) {
            this.form = fb.group({
                code: new FormControl(),
                name: new FormControl(),
                description: new FormControl() ,
                price: new FormControl()
            });
            this.product = null;
        };

    ngOnInit(): void {
        let id = this.route.snapshot.paramMap.get('id');
        this.getProductById(id);
    }

    getProductById(id: any): void {
        this.productService
        .getProductById(id)
        .subscribe((product) => {
            this.product = product;
            this.setDefaultCode(this.product.code);
            this.setDefaultName(this.product.name);
            this.setDefaultDescription(this.product.description);
            this.setDefaultPrice(this.product.price);
        })
        
    }

    setDefaultCode(code: string): void {
            this.form.controls.code.setValue(code);
    }
    setDefaultName(name: string): void {
        this.form.controls.name.setValue(name);
    }
    setDefaultDescription(description: string): void {
        this.form.controls.description.setValue(description);
    }
    setDefaultPrice(price: number): void {
        this.form.controls.price.setValue(price);
    }

    get code(): AbstractControl {
        return this.form.controls.code;
    }

    get name(): AbstractControl {
        return this.form.controls.name;
    }

    get description(): AbstractControl {
        return this.form.controls.description;
    }

    get price(): AbstractControl {
        return this.form.controls.price;
    }

    get product_id() {
        return Number(this.route.snapshot.paramMap.get('id'));;
    }

    updateProduct(): void {
        let name = this.name.value ? this.name.value : "";
        let code = this.code.value ? this.code.value : "";
        let description = this.description.value ? this.description.value : "";
        let price = this.price.value ? this.price.value : "";
        let id = this.product_id;

        let productRequest = new ProductRequest(code, name, description, price, "");
        this.productService.updateProduct(id, productRequest).subscribe((product) => {
            if (product){
                this.commonService.updateToastData("Success updating product", 'success', 'Product updated.');
            }
        });
    }
}