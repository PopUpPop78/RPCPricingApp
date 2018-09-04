import { PricingRequest } from "./pricing-request.model";
import { PricingResponse } from "./pricing-response.model";


export class PricingDocument {

    PricingId: string
    Request: PricingRequest
    Response: PricingResponse[]

}
