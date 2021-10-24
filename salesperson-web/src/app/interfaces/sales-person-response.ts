import { SalesPerson } from "./sales-person";

export interface SalesPersonResponse {
    salesPersonFound: boolean;
    salesPerson: SalesPerson;
}