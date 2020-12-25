import { Component, OnInit } from '@angular/core';
import { ChatArchiveService } from 'backend/api/chatArchive.service';
import { ChatSummaryDto } from 'backend/model/chatSummaryDto';

@Component({
  selector: 'app-hourly-report',
  templateUrl: './hourly-report.component.html',
  styleUrls: ['./hourly-report.component.css'],
})
export class HourlyReportComponent implements OnInit {
  results: ChatSummaryDto[];
  constructor(private chatService: ChatArchiveService) {
  }
  ngOnInit(): void {
    this.chatService.chatarchiveSummaryHourlyGet().subscribe(result => this.results = result);
  }
}
