import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Recipe } from '../Interfaces/recipe';

@Injectable({
  providedIn: 'root'
})
export class RecipeService {
  private rootUrl = 'https://localhost:7062/api/Recipe';

  constructor(private http: HttpClient) {}

  addRecipe(recipe: Recipe): Observable<any> {
    return this.http.post(this.rootUrl, recipe);
  }

  getAllRecipes(): Observable<any> {
    return this.http.get(this.rootUrl);
  }

  getAllRecipesByTag(tag: string): Observable<Recipe[]> {
    return this.http.get<Recipe[]>(`$this.rootUrl/filter?dietaryTag=${tag}`);
  }

  getRecipeById(id: number): Observable<Recipe> {
    return this.http.get<Recipe>(`${this.rootUrl}/${id}`);
  }

  updateRecipe(id: number, recipe: Recipe): Observable<any> {
    return this.http.put(`$this.rootUrl/${id}`, recipe);
  }

  deleteRecipeById(id: number): Observable<any> {
    return this.http.delete(`${this.rootUrl}/${id}`)
  }
}
