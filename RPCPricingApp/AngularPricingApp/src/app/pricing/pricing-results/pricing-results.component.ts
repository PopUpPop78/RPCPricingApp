import { Component, OnInit } from '@angular/core';

import { PricingService } from '../shared/pricing.service';

@Component({
  selector: 'app-pricing-results',
  templateUrl: './pricing-results.component.html',
  styleUrls: ['./pricing-results.component.css']
})
export class PricingResultsComponent implements OnInit {

  constructor(private pricingService:PricingService) { }

  ngOnInit() {
  }

  

}
