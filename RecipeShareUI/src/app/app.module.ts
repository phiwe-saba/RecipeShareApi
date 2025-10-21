/*import { Routes } from '@angular/router';
import { HomeComponent } from './Recipes/home/home.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: 'AddRecipe',
    loadComponent: () =>
      import('./Recipes/add-recipe/add-recipe.component').then(
        (m) => m.AddRecipeComponent
      ),
  },
];

*/

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { HomeComponent } from './Recipes/home/home.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    NgbModule,
    ToastrModule.forRoot()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
