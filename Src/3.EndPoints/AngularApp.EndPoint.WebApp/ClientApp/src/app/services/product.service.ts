import { Injectable } from '@angular/core';
import { EntityApiService } from './entity-api.service';
import { HttpClient } from '@angular/common/http';
import IProduct from '../models/IProduct.dto';

@Injectable({
  providedIn: 'root',
})
export class ProductService extends EntityApiService<IProduct>
{
  constructor(httpClient:HttpClient) {
    super(httpClient);
    this.baseUrl = "Product";
    console.log("Run Product Service ...");
  }
}
