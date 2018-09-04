import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';


import { PricingService } from '../shared/pricing.service';
import { PricingDocument } from '../shared/pricing-document.model';
import { PricingRequest } from '../shared/pricing-request.model';

@Component({
  selector: 'app-pricing-data',
  templateUrl: './pricing-data.component.html',
  styleUrls: ['./pricing-data.component.css']
})
export class PricingDataComponent implements OnInit {

  constructor(private pricingService:PricingService) { }


  ngOnInit() {
    this.loadExecutionTypes();
    this.resetForm();    
  }

  resetForm(form?: NgForm){
    if(form != null)
      form.reset();
    this.pricingService.selectedPricingDocument = new PricingDocument();
    this.pricingService.selectedPricingDocument.Request = new PricingRequest();
  }


  updateExecutionType(executionType:string){
    this.pricingService.selectedPricingDocument.Request.ExecutionType = executionType;
  }

  loadExecutionTypes(){    
    this.pricingService.getExecutionTypes().subscribe(data=>{
      this.pricingService.executionTypes = data;
    });
  }

  onSubmit(form: NgForm){
    this.pricingService.selectedPricingDocument.Response = [];
    this.pricingService.loading = true;
    this.pricingService.postPricingDocument(form.value).subscribe(data=>{
      this.pricingService.selectedPricingDocument = data;
      this.pricingService.loading = false;
    }, err=>{
      this.pricingService.loading = false;
    });
    ;


  }

}
