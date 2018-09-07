import { PricingRequest } from "./pricing-request.model";
import { PricingResponse } from "./pricing-response.model";


export class PricingDocument {

    pricingId: string;
    request: PricingRequest;
    response: PricingResponse[];
    error:string;

}
