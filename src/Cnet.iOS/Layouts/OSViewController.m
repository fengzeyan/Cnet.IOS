//
//  OSViewController.m
//  College Nannies and Tutors Layouts
//
//  Created by kristian.lien on 2/21/14.
//  Copyright (c) 2014 Onsharp. All rights reserved.
//

#import "OSViewController.h"

@interface OSViewController ()

@end

@implementation OSViewController

@synthesize messagesButton, upcomingButton, completedButton;

- (IBAction)mailPressedTest:(id)sender
{
    if (newMessages)
    {
        UIImage *image = [UIImage imageNamed:@"MAIL.png"];
        [messagesButton setImage:image forState:UIControlStateNormal];
        newMessages = false;
    }
    else
    {
        UIImage *image = [UIImage imageNamed:@"MESSAGES.png"];
        [messagesButton setImage:image forState:UIControlStateNormal];
        newMessages = true;
    }
}

-(IBAction)upcomingSwitchPressed:(id)sender
{
    if (completedListDisplayed)
    {
        UIImage *upcomingImage = [UIImage imageNamed:@"control-tab-left-on.png"];
        UIImage *completedImage = [UIImage imageNamed:@"control-tab-right-off.png"];
        [upcomingButton setBackgroundImage:upcomingImage forState:UIControlStateNormal];
        [completedButton setBackgroundImage:completedImage forState:UIControlStateNormal];
        completedListDisplayed = false;
    }
}

-(IBAction)completedSwitchPressed:(id)sender
{
    if (!completedListDisplayed)
    {
        UIImage *completedImage = [UIImage imageNamed:@"control-tab-right-on.png"];
        UIImage *upcomingImage = [UIImage imageNamed:@"control-tab-left-off"];
        [completedButton setBackgroundImage:completedImage forState:UIControlStateNormal];
        [upcomingButton setBackgroundImage:upcomingImage forState:UIControlStateNormal];
        completedListDisplayed = true;
    }
}

#pragma mark -
#pragma mark Table View Methods

-(UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    OSAssignmentsTableViewCell *cell = (OSAssignmentsTableViewCell *) [tableView dequeueReusableCellWithIdentifier:@"AssignmentsCellIdentifier"];
    // Get real data here ***
    NSString *familyName = @"Anderson";
    NSString *commitmentLevel = @"PT";
    [cell.familyNameLabel setText:[NSString stringWithFormat:@"%@ Family - %@", familyName, commitmentLevel]];
    return cell;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    return [testArray count];
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    // Bring up editing screen ***
}

#pragma mark -
#pragma mark Controller Methods

- (void)viewDidLoad
{
    [super viewDidLoad];
	// Do any additional setup after loading the view, typically from a nib.
    newMessages = true;
    testArray = [NSArray arrayWithObjects:@"Test 1", @"Test 2", nil]; // Make this non-static ***
    completedTestArray = [NSArray arrayWithObjects:@"Test 1", @"Test 2", @"Test 3", @"Test 4", @"Test 5", @"Test 6", @"Test 7", nil];
    
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

@end
