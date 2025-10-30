import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WebApiService } from './web-api.service';
import { Recipe } from '../Interfaces/recipe';

var apiUrl = "https://localhost:7062/";

var httpLink = {
  getAllRecipes: apiUrl + "api/Recipe",
  deleteRecipeById: apiUrl + "api/Recipe/",
  getRecipeById: apiUrl + "api/Recipe/",
  addRecipe: apiUrl + "api/Recipe",
  getRecipeByTag: apiUrl + "api/Recipe/"
}

console.log("all recipes:", httpLink.getAllRecipes)
console.log(httpLink.addRecipe);

@Injectable({
  providedIn: 'root'
})

export class HttpProviderService {

  constructor(private weApiService: WebApiService) { }

  public getAllRecipes(): Observable<Recipe[]> {
    return this.weApiService.get(httpLink.getAllRecipes);
  }

  public deleteRecipeById(id: number): Observable<any> {
    return this.weApiService.delete(`${httpLink.deleteRecipeById}${id}`);
  }

  public getRecipeById(id: number): Observable<any> {
    return this.weApiService.get(`${httpLink.getRecipeById}${id}`);
  }

  public addRecipe(model: any): Observable<any> {
    console.log(httpLink.addRecipe);
    return this.weApiService.post(httpLink.addRecipe, model);
  }

  public updateRecipe(id: number, recipe: Recipe): Observable<Recipe> {
    return this.weApiService.put(`${httpLink.getAllRecipes}/${id}`, recipe);
  }

  public getAllRecipesByTag(dietaryTag: string): Observable<Recipe[]> {
    return this.weApiService.get(`${httpLink.getRecipeByTag}filter?dietaryTag=${dietaryTag}`);
  }
}
