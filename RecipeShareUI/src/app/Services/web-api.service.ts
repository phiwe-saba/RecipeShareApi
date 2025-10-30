import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { map } from 'rxjs/operators';
import { catchError } from 'rxjs/internal/operators/catchError';
import { HttpHeaders, HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class WebApiService {
  constructor(private httpClient: HttpClient) {}

  public get(url: string): Observable<any> {
    return this.httpClient.get(url, { observe: 'body' });
  }

  public delete(url: string): Observable<any> {
    return this.httpClient.delete(url, { observe: 'body'});
  }

  public put(url: string, model: any): Observable<any> {
    return this.httpClient.put(url, model)
  }

  // Post call method
  post(url: string, model: any): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      }),
      observe: "response" as 'body'
    };
    return this.httpClient.post(
      url,
      model, httpOptions)
      .pipe(
        map((response: any) => this.ReturnResponseData(response)),
        catchError(this.handleError)
      );
  }

  private handleError(error: any){
    return throwError(error);
  }
  
  private ReturnResponseData(response: any) {
    return response;
  }
  
}
