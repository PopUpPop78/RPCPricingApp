import { Component, OnInit } from '@angular/core';

import { PricingService } from './shared/pricing.service';

@Component({
  selector: 'app-pricing',
  templateUrl: './pricing.component.html',
  styleUrls: ['./pricing.component.css'],
  providers: [PricingService],
})
export class PricingComponent implements OnInit {

  constructor(private pricingService:PricingService) { }

  ngOnInit() {
  }

}
