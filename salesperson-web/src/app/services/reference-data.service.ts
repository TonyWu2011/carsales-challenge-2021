import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { ReferenceData } from '../interfaces/reference-data';

@Injectable({
  providedIn: 'root'
})
export class ReferenceDataService {

  private referenceDataUrl = 'ReferenceData';  // URL to web api

  constructor(
    private http: HttpClient) { }

  getReferenceData(): Observable<ReferenceData> {
    return this.http.get<ReferenceData>(this.referenceDataUrl)
    .pipe(
      catchError(this.handleError<ReferenceData>('getReferenceData', {} as ReferenceData))
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
