import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Recipe } from '../models/recipe.model';

@Injectable({
  providedIn: 'root'
})
export class RecipeService {
  constructor(private http: HttpClient) {}

  /*retrieveAllRecipes(recipe: Recipe): Observable<any> {
    var rootUrl = 'https://localhost:7062/api/Recipe';

    console.log("URL", rootUrl);

    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    //return this.http.get(rootUrl, recipe, { headers })

  }*/
  
}
