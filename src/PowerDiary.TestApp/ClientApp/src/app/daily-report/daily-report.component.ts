import { Component, OnInit } from '@angular/core';
import { DailyChatInputDto } from 'backend';
import { ChatArchiveService } from 'backend/api/chatArchive.service';
import { ChatEventTypesService } from 'backend/api/chatEventTypes.service';
import { DailyChatOutputDto } from 'backend/model/dailyChatOutputDto';

@Component({
  selector: 'app-daily-report',
  templateUrl: './daily-report.component.html',
  styleUrls: ['./daily-report.component.css'],
})
export class DailyReportComponent implements OnInit {
  dto: DailyChatInputDto = { pageNumber: 1, pageSize: 10 };
  result: DailyChatOutputDto;
  eventTypes: any;

  constructor(private chatService: ChatArchiveService, private chatEventTypes: ChatEventTypesService) { }

  ngOnInit(): void {
    this.loadDailyChat();
    this.loadEventTypes();
  }

  loadEventTypes() {
    this.eventTypes = this.chatEventTypes.chateventtypesGet().subscribe(results => this.eventTypes = results);
  }

  loadDailyChat() {
    this.chatService.chatarchiveDailyPost(this.dto).subscribe(result => this.result = result);
  }

  pageChanged(event): void {
    this.dto.pageNumber = event.pageIndex + 1;
    this.loadDailyChat();
  }

  eventTypeChanged(): void {
    this.dto.pageNumber = 1;
    this.loadDailyChat();
  }
}
