import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { SalesGroup } from '../interfaces/sales-group';

@Injectable({
  providedIn: 'root'
})
export class SalesGroupService {

  private salesGroupUrl = 'SalesGroup';  // URL to web api

  constructor(
    private http: HttpClient) { }

  getSalesGroups(): Observable<SalesGroup[]> {
    return this.http.get<SalesGroup[]>(this.salesGroupUrl)
    .pipe(
      catchError(this.handleError<SalesGroup[]>('getSalesGroups', []))
    );
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
