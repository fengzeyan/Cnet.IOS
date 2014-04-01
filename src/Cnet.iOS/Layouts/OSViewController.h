//
//  OSViewController.h
//  College Nannies and Tutors Layouts
//
//  Created by kristian.lien on 2/21/14.
//  Copyright (c) 2014 Onsharp. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "OSAssignmentsTableViewCell.h"

@interface OSViewController : UIViewController <UITableViewDataSource, UITableViewDelegate>
{
    BOOL newMessages;
    BOOL completedListDisplayed;
    IBOutlet UIButton *messagesButton;
    IBOutlet UIButton *upcomingButton;
    IBOutlet UIButton *completedButton;
    NSArray *testArray;
    NSArray *completedTestArray;
    
}

@property(nonatomic, strong) IBOutlet UIButton *messagesButton;
@property(nonatomic, strong) IBOutlet UIButton *upcomingButton;
@property(nonatomic, strong) IBOutlet UIButton *completedButton;

@end
