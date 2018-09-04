import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestMethod, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { PricingDocument } from './pricing-document.model';


@Injectable()
export class PricingService {

  selectedPricingDocument: PricingDocument
  executionTypes:string[];

  private apiUrl:string = 'http://localhost:51063/api/BasicPricing/';
  public loading:boolean = false;

  constructor(private http: Http) {
   }

   postPricingDocument(doc: PricingDocument){
     var body = JSON.stringify(this.selectedPricingDocument);
     var headerOptions = new Headers({'Content-Type':'application/json'});
     var requestOptions = new RequestOptions({method : RequestMethod.Post, headers : headerOptions});
     return this.http.post(this.apiUrl, body, requestOptions).map(x=> x.json());
   }

   getExecutionTypes(){
     return this.http.get(this.apiUrl).map(x=>x.json());
   }

}
