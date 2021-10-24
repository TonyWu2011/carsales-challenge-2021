import { Injectable } from '@angular/core';
import { Observable, of , Subject} from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { environment } from 'src/environments/environment';
import { SalesPerson } from '../interfaces/sales-person';
import { SalesPersonRequest } from '../interfaces/sales-person-request';
import { SalesPersonResponse } from '../interfaces/sales-person-response';

@Injectable({
  providedIn: 'root'
})
export class SalesPersonService {

  private salesPersonUrl = 'SalesPerson';  // URL to web api

  private salesPeopleUpdatedSource = new Subject();
  salesPeopleUpdated = this.salesPeopleUpdatedSource.asObservable();

  constructor(private http: HttpClient) { }

  getSalesPeople(): Observable<SalesPerson[]> {
    return this.http.get<SalesPerson[]>(`${environment.apiBaseUrl}${this.salesPersonUrl}`)
    .pipe(
      catchError(this.handleError<SalesPerson[]>('getSalesPerson', []))
    );
  }

  assignSalesPerson(carType: number, languageOption: number): Observable<SalesPersonResponse> {
    const salesPersonRequest: SalesPersonRequest = {
      carType : carType,
      languageOption : languageOption
    };

    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    return this.http.post<SalesPersonResponse>(`${environment.apiBaseUrl}${this.salesPersonUrl}/AssignFree`, salesPersonRequest, httpOptions)
      .pipe (
        catchError(this.handleError<SalesPersonResponse>('assignSalesPerson', {} as SalesPersonResponse))
      );
  }

  salesPeopleChanged(): void {
    this.salesPeopleUpdatedSource.next();
  }

  /**
  * Handle Http operation that failed.
  * Let the app continue.
  * @param operation - name of the operation that failed
  * @param result - optional value to return as the observable result
  */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
