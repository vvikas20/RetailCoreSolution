import { Routes } from "@angular/router";
import { FeatureoneComponent } from "./featureone.component";
import { ProjectScheduleComponent } from "./pages/project-schedule/project-schedule.component";
import { ProjectInfoComponent } from "./pages/project-info/project-info.component";
import { ProjectUserListComponent } from "./pages/project-user-list/project-user-list.component";
import { MyProjectComponent } from "./pages/my-project/my-project.component";
import { ProjectSupportRequestComponent } from "./pages/project-support-request/project-support-request.component";

const Featureone_Routes: Routes = [
    {
        path: '', component: FeatureoneComponent,
        children: [
            { path: '', redirectTo: 'my-project', pathMatch: 'full' },
            { path: 'my-project', component: MyProjectComponent },
            { path: 'project-schedule', component: ProjectScheduleComponent },
            { path: 'project-info', component: ProjectInfoComponent },
            { path: 'project-user-list', component: ProjectUserListComponent },
            { path: 'project-support', component: ProjectSupportRequestComponent },
        ]
    }
];

export { Featureone_Routes }