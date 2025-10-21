import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WebApiService } from './web-api.service';

var apiUrl = "https://localhost:7062/";

var httpLink = {
  getAllRecipes: apiUrl + "",
  deleteRecipeById: apiUrl + "",
  getRecipeById: apiUrl + "",
  addRecipe: apiUrl + ""
}

@Injectable({
  providedIn: 'root'
})

export class HttpProviderService {

  constructor(private wepApiService: WebApiService) { }

  public getAllRecipes(): Observable<any> {
    return this.wepApiService.get(httpLink.getAllRecipes);
  }

  public deleteRecipeById(model: any): Observable<any> {
    return this.wepApiService.post(httpLink.deleteRecipeById + '?recipeId=' + model, "");
  }

  public getRecipeById(model: any): Observable<any> {
    return this.wepApiService.get(httpLink.getRecipeById + '?recipeId=' + model);
  }

  public addRecipe(model: any): Observable<any> {
    return this.wepApiService.post(httpLink.addRecipe, model);
  }
}
