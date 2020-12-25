import { Component, OnInit } from '@angular/core';
import { HttpLoaderService } from 'src/app/http-loader.service';

@Component({
  selector: 'app-loading-indicator',
  templateUrl: './loading-indicator.component.html',
  styleUrls: ['./loading-indicator.component.css'],
})
export class LoadingIndicatorComponent implements OnInit {
  constructor(public loadingService: HttpLoaderService) {}

  ngOnInit(): void {}
}
