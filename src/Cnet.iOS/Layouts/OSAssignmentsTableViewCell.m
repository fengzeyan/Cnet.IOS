//
//  OSCustomTableViewCell.m
//  College Nannies and Tutors Layouts
//
//  Created by kristian.lien on 2/24/14.
//  Copyright (c) 2014 Onsharp. All rights reserved.
//

#import "OSAssignmentsTableViewCell.h"

@implementation OSAssignmentsTableViewCell

@synthesize familyNameLabel, profileImage, infoImage, belowProfilePicLabel, purpleInfoLabel, timeLabel, dateLabel, locationLabel, childrenLabel, bookmarkImage;

- (id)initWithStyle:(UITableViewCellStyle)style reuseIdentifier:(NSString *)reuseIdentifier
{
    self = [super initWithStyle:style reuseIdentifier:reuseIdentifier];
    if (self) {
        // Initialization code
    }
    return self;
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated
{
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

@end
