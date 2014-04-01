//
//  OSAssignmentsTableViewCell.h
//  College Nannies and Tutors Layouts
//
//  Created by kristian.lien on 2/24/14.
//  Copyright (c) 2014 Onsharp. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface OSAssignmentsTableViewCell : UITableViewCell
{
    IBOutlet UILabel *familyNameLabel;
    IBOutlet UIImageView *profileImage;
    IBOutlet UIImageView *infoImage;
    IBOutlet UILabel *belowProfilePicLabel;
    IBOutlet UILabel *purpleInfoLabel;
    IBOutlet UILabel *timeLabel;
    IBOutlet UILabel *dateLabel;
    IBOutlet UILabel *locationLabel;
    IBOutlet UILabel *childrenLabel;
    IBOutlet UIImageView *bookmarkImage;
    
}

@property(nonatomic, strong) IBOutlet UILabel *familyNameLabel;
@property(nonatomic, strong) IBOutlet UIImageView *profileImage;
@property(nonatomic, strong) IBOutlet UIImageView *infoImage;
@property(nonatomic, strong) IBOutlet UILabel *belowProfilePicLabel;
@property(nonatomic, strong) IBOutlet UILabel *purpleInfoLabel;
@property(nonatomic, strong) IBOutlet UILabel *timeLabel;
@property(nonatomic, strong) IBOutlet UILabel *dateLabel;
@property(nonatomic, strong) IBOutlet UILabel *locationLabel;
@property(nonatomic, strong) IBOutlet UILabel *childrenLabel;
@property(nonatomic, strong) IBOutlet UIImageView *bookmarkImage;

@end
