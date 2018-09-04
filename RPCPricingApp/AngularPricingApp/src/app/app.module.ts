import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { LoadingModule } from 'ngx-loading';
import { CurrencyMaskModule } from "ng2-currency-mask";
import { CurrencyMaskConfig, CURRENCY_MASK_CONFIG } from "ng2-currency-mask/src/currency-mask.config";
export const CustomCurrencyMaskConfig: CurrencyMaskConfig = {
  align: "left",
  allowNegative: false,
  decimal: "",
  precision: 0,
  prefix: "£ ",
  suffix: "",
  thousands: ","
};

import { AppComponent } from './app.component';
import { PricingComponent } from './pricing/pricing.component';
import { PricingDataComponent } from './pricing/pricing-data/pricing-data.component';
import { PricingResultsComponent } from './pricing/pricing-results/pricing-results.component';
import { LoginComponent } from './login/login.component';
import { LoginService } from './login/shared/login.service';


@NgModule({
  declarations: [
    AppComponent,
    PricingComponent,
    PricingDataComponent,
    PricingResultsComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    LoadingModule,
    CurrencyMaskModule,
  ],
  providers: [{provide: CURRENCY_MASK_CONFIG, useValue: CustomCurrencyMaskConfig}],
  bootstrap: [AppComponent]
})
export class AppModule { }
