import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { BASE_PATH } from 'backend';
import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

const providers = [
  { provide: BASE_PATH, useValue: 'https://localhost:44301' }
];

if (environment.production) {
  enableProdMode();
}

platformBrowserDynamic(providers).bootstrapModule(AppModule)
  .catch(err => console.log(err));
