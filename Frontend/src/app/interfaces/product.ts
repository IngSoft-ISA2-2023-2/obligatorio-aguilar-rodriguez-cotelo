export interface Product {
    id: number;
    code: string;
    name: string;
    description: string;
    price: number;
    quantity?: number | undefined;
    pharmacy: {
      id: number;
      name: string;  
    };
  }

  export class ProductRequest {
    code: string;
    name: string;
    description: string;
    price: number;
    pharmacyName: string = "";
    quantity?: number | undefined;

    constructor(code: string, name: string, description: string,  price: number, 
       pharmacyName: string){
      this.code = code;
      this.name = name;
      this.description = description;
      this.price = price;
      this.pharmacyName = pharmacyName;
    }
  }
