//
//  OSProfileViewController.m
//  College Nannies and Tutors Layouts
//
//  Created by kristian.lien on 3/20/14.
//  Copyright (c) 2014 Onsharp. All rights reserved.
//

#import "OSProfileViewController.h"

@interface OSProfileViewController ()

@end

@implementation OSProfileViewController

#pragma mark -
#pragma mark Table View Methods

-(UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    UITableViewCell *cell = [UITableViewCell alloc];
    OSProfileCell *profileCell;
    
    if ([tableView cellForRowAtIndexPath:indexPath] == nil)
    {
        profileCell = (OSProfileCell *) [tableView dequeueReusableCellWithIdentifier:@"ProfileCellIdentifier"];
        
        switch (indexPath.row)
        {
            case 0:
                [profileCell.iconImage setImage:[UIImage imageNamed:@"icon-mail.png"]];
                [profileCell.phoneIconImage setHidden:true];
                break;
                
            case 1:
                [profileCell.iconImage setImage:[UIImage imageNamed:@"icon-phone.png"]];
                [profileCell.profileLabel setText:@"612-555-1212"];
                break;
            
            case 2:
                [profileCell.iconImage setImage:[UIImage imageNamed:@"icon-street.png"]];
                [profileCell.profileLabel setText:@"123 Main Street"];
                [profileCell.phoneIconImage setHidden:true];
                break;
                
            case 3:
                [profileCell.iconImage setImage:[UIImage imageNamed:@"icon-city.png"]];
                [profileCell.profileLabel setText:@"Marshall, MN 55555"];
                [profileCell.phoneIconImage setHidden:true];
                break;
                
            case 4:
                [profileCell.iconImage setHidden:true];
                [profileCell.profileLabel setText:@"Emergency Contact"];
                profileCell.profileLabel.font = [UIFont fontWithName:@"HelveticaNeue-Bold" size:15];
                [profileCell.phoneIconImage setHidden:true];
                break;
                
            case 5:
                [profileCell.iconImage setImage:[UIImage imageNamed:@"icon-user.png"]];
                [profileCell.profileLabel setText:@"Jane Smith"];
                [profileCell.phoneIconImage setHidden:true];
                break;
                
            case 6:
                [profileCell.iconImage setImage:[UIImage imageNamed:@"icon-phone.png"]];
                [profileCell.profileLabel setText:@"612-555-1234"];
                [profileCell.phoneIconImage setImage:[UIImage imageNamed:@"icon-home.png"]];
                break;
                
            default:
                break;
        }

        return profileCell;
    }
    
    return cell;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    return [testArray count];
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    // Open profile item here ***
}

#pragma mark -
#pragma mark Controller Methods

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        // Custom initialization
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
    // Do any additional setup after loading the view.
    
    testArray = [NSArray arrayWithObjects:@"Test 1", @"Test 2", @"Test 3", @"Test 4", @"Test 5", @"Test 6", @"Test 7", nil]; // Make this non-static ***
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

/*
#pragma mark - Navigation

// In a storyboard-based application, you will often want to do a little preparation before navigation
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender
{
    // Get the new view controller using [segue destinationViewController].
    // Pass the selected object to the new view controller.
}
*/

@end
