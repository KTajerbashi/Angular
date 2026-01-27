import { Injectable } from '@angular/core';
import { EntityApiService } from './entity-api.service';
import { HttpClient } from '@angular/common/http';
import IProduct from '../models/IProduct.dto';

@Injectable({
  providedIn: 'root',
})
export class ProductApiService extends EntityApiService<IProduct, string> {
  protected override endpoint = 'Product';
}
