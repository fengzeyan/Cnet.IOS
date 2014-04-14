#pragma clang diagnostic ignored "-Wdeprecated-declarations"
#include <stdarg.h>
#include <monotouch/monotouch.h>
#include <objc/objc.h>
#include <objc/runtime.h>
#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>


bool native_to_managed_trampoline_1 (id self, MonoMethod **managed_method_ptr, id p0, id p1, const char *r0, const char *r1, const char *r2, const char *r3)
{
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [2];
	MonoObject *mthis;
	if (mono_domain_get () == NULL)
		mono_jit_thread_attach (NULL);
	if (!managed_method) {
		const char *paramptr[2] = { r0, r1 };
		managed_method = get_method_direct (r2, r3, 2, paramptr)->method;
		*managed_method_ptr = managed_method;
	}
	mthis = NULL;
	if (self) {
		mthis = get_managed_object_for_ptr_fast (self, true);
	}
	NSObject *nsobj0 = (NSObject *) p0;
	MonoObject *mobj0 = NULL;
	bool created0 = false;
	if (nsobj0) {
		mobj0 = get_nsobject_with_type_for_ptr_created (nsobj0, false, monotouch_get_parameter_type (managed_method, 0), &created0);
	}
	arg_ptrs [0] = mobj0;
	NSObject *nsobj1 = (NSObject *) p1;
	MonoObject *mobj1 = NULL;
	bool created1 = false;
	if (nsobj1) {
		mobj1 = get_nsobject_with_type_for_ptr_created (nsobj1, false, monotouch_get_parameter_type (managed_method, 1), &created1);
	}
	arg_ptrs [1] = mobj1;

	void * retval = mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

	bool res;
	res = *(bool *) mono_object_unbox (retval);

	return res;
}


bool native_to_managed_trampoline_2 (id self, MonoMethod **managed_method_ptr, void * p0, const char *r0, const char *r1, const char *r2)
{
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [1];
	MonoObject *mthis;
	if (mono_domain_get () == NULL)
		mono_jit_thread_attach (NULL);
	if (!managed_method) {
		const char *paramptr[1] = { r0 };
		managed_method = get_method_direct (r1, r2, 1, paramptr)->method;
		*managed_method_ptr = managed_method;
	}
	mthis = NULL;
	if (self) {
		mthis = get_managed_object_for_ptr_fast (self, true);
	}
	void * a0 = p0;
	arg_ptrs [0] = &a0;

	void * retval = mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

	bool res;
	res = *(bool *) mono_object_unbox (retval);

	return res;
}


id native_to_managed_trampoline_3 (id self, MonoMethod **managed_method_ptr, const char *r0, const char *r1)
{
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [0];
	MonoObject *mthis;
	if (mono_domain_get () == NULL)
		mono_jit_thread_attach (NULL);
	if (monotouch_try_get_nsobject (self))
		return self;
	if (!managed_method) {
		managed_method = get_method_direct (r0, r1, 0, NULL)->method;
		*managed_method_ptr = managed_method;
	}
	mthis = mono_object_new (mono_domain_get (), mono_method_get_class (managed_method));
	mono_field_set_value (mthis, monotouch_nsobject_handle_field, &self);
	mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);
	monotouch_create_managed_ref (self, mthis, true);

	return self;
}


id native_to_managed_trampoline_4 (id self, MonoMethod **managed_method_ptr, const char *r0, const char *r1)
{
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [0];
	MonoObject *mthis;
	if (mono_domain_get () == NULL)
		mono_jit_thread_attach (NULL);
	if (!managed_method) {
		managed_method = get_method_direct (r0, r1, 0, NULL)->method;
		*managed_method_ptr = managed_method;
	}
	mthis = NULL;
	if (self) {
		mthis = get_managed_object_for_ptr_fast (self, true);
	}
	void * retval = mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

	id res;
	if (!retval) {
		res = NULL;
	} else {
		id retobj;
		mono_field_get_value ((MonoObject *) retval, monotouch_nsobject_handle_field, (void **) &retobj);
		[retobj retain];
		[retobj autorelease];
		res = retobj;
	}

	return res;
}


void native_to_managed_trampoline_5 (id self, MonoMethod **managed_method_ptr, unsigned int p0, CGRect p1, const char *r0, const char *r1, const char *r2, const char *r3)
{
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [2];
	MonoObject *mthis;
	if (mono_domain_get () == NULL)
		mono_jit_thread_attach (NULL);
	if (!managed_method) {
		const char *paramptr[2] = { r0, r1 };
		managed_method = get_method_direct (r2, r3, 2, paramptr)->method;
		*managed_method_ptr = managed_method;
	}
	mthis = NULL;
	if (self) {
		mthis = get_managed_object_for_ptr_fast (self, true);
	}
	arg_ptrs [0] = &p0;
	arg_ptrs [1] = &p1;

	mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

	return;
}


void native_to_managed_trampoline_6 (id self, MonoMethod **managed_method_ptr, const char *r0, const char *r1)
{
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [0];
	MonoObject *mthis;
	if (mono_domain_get () == NULL)
		mono_jit_thread_attach (NULL);
	if (!managed_method) {
		managed_method = get_method_direct (r0, r1, 0, NULL)->method;
		*managed_method_ptr = managed_method;
	}
	mthis = NULL;
	if (self) {
		mthis = get_managed_object_for_ptr_fast (self, true);
	}
	mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

	return;
}


void native_to_managed_trampoline_7 (id self, MonoMethod **managed_method_ptr, id p0, const char *r0, const char *r1, const char *r2)
{
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [1];
	if (mono_domain_get () == NULL)
		mono_jit_thread_attach (NULL);
	if (!managed_method) {
		const char *paramptr[1] = { r0 };
		managed_method = get_method_direct (r1, r2, 1, paramptr)->method;
		*managed_method_ptr = managed_method;
	}
	NSObject *nsobj0 = (NSObject *) p0;
	MonoObject *mobj0 = NULL;
	bool created0 = false;
	if (nsobj0) {
		mobj0 = get_nsobject_with_type_for_ptr_created (nsobj0, false, monotouch_get_parameter_type (managed_method, 0), &created0);
	}
	arg_ptrs [0] = mobj0;

	mono_runtime_invoke (managed_method, NULL, arg_ptrs, NULL);

	return;
}


void native_to_managed_trampoline_8 (id self, MonoMethod **managed_method_ptr, id p0, id p1, const char *r0, const char *r1, const char *r2, const char *r3)
{
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [2];
	MonoObject *mthis;
	if (mono_domain_get () == NULL)
		mono_jit_thread_attach (NULL);
	if (!managed_method) {
		const char *paramptr[2] = { r0, r1 };
		managed_method = get_method_direct (r2, r3, 2, paramptr)->method;
		*managed_method_ptr = managed_method;
	}
	mthis = NULL;
	if (self) {
		mthis = get_managed_object_for_ptr_fast (self, true);
	}
	NSObject *nsobj0 = (NSObject *) p0;
	MonoObject *mobj0 = NULL;
	bool created0 = false;
	if (nsobj0) {
		mobj0 = get_nsobject_with_type_for_ptr_created (nsobj0, false, monotouch_get_parameter_type (managed_method, 0), &created0);
	}
	arg_ptrs [0] = mobj0;
	NSObject *nsobj1 = (NSObject *) p1;
	MonoObject *mobj1 = NULL;
	bool created1 = false;
	if (nsobj1) {
		mobj1 = get_nsobject_with_type_for_ptr_created (nsobj1, false, monotouch_get_parameter_type (managed_method, 1), &created1);
	}
	arg_ptrs [1] = mobj1;

	mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

	return;
}


bool native_to_managed_trampoline_9 (id self, MonoMethod **managed_method_ptr, SEL p0, const char *r0, const char *r1, const char *r2)
{
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [1];
	MonoObject *mthis;
	if (mono_domain_get () == NULL)
		mono_jit_thread_attach (NULL);
	if (!managed_method) {
		const char *paramptr[1] = { r0 };
		managed_method = get_method_direct (r1, r2, 1, paramptr)->method;
		*managed_method_ptr = managed_method;
	}
	mthis = NULL;
	if (self) {
		mthis = get_managed_object_for_ptr_fast (self, true);
	}
	arg_ptrs [0] = p0 ? monotouch_get_selector (p0) : NULL;

	void * retval = mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

	bool res;
	res = *(bool *) mono_object_unbox (retval);

	return res;
}



@interface AppDelegate : NSObject/*<UIApplicationDelegate>*/ {
	int __monoObjectGCHandle;
}
	-(void) release;
	-(id) retain;
	-(void) dealloc;
	-(bool) application:(id)p0 didFinishLaunchingWithOptions:(id)p1;
	-(bool) conformsToProtocol:(void *)p0;
	-(id) init;
@end
@implementation AppDelegate { } 
	-(void) release
	{
		monotouch_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return monotouch_retain_trampoline (self, _cmd);
	}

	-(void) dealloc
	{
		monotouch_unregister_object (self);
		monotouch_free_gchandle (self);
		[super dealloc];
	}

	-(bool) application:(id)p0 didFinishLaunchingWithOptions:(id)p1
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_1 (self, &managed_method, p0, p1, "MonoTouch.UIKit.UIApplication, monotouch", "MonoTouch.Foundation.NSDictionary, monotouch", "TimesSquareiOSSample.AppDelegate, TimesSquareiOSSample", "FinishedLaunching");
	}

	-(bool) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_2 (self, &managed_method, p0, "System.IntPtr, mscorlib", "MonoTouch.Foundation.NSObject, monotouch", "InvokeConformsToProtocol");
	}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, &managed_method, "TimesSquareiOSSample.AppDelegate, TimesSquareiOSSample", ".ctor");
	}
@end

@interface TSQCalendarCell : UITableViewCell {
}
	-(id) firstOfMonth;
	-(void) setFirstOfMonth:(id)p0;
	-(unsigned int) daysInWeek;
	-(id) calendar;
	-(void) setCalendar:(id)p0;
	-(id) calendarView;
	-(void) setCalendarView:(id)p0;
	-(id) textColor;
	-(void) setTextColor:(id)p0;
	-(CGSize) shadowOffset;
	-(void) setShadowOffset:(CGSize)p0;
	-(float) columnSpacing;
	-(void) setColumnSpacing:(float)p0;
	-(void) layoutViewsForColumnAtIndex:(unsigned int)p0 inRect:(CGRect)p1;
	-(id) init;
	-(id) initWithCoder:(id)p0;
	-(id) initWithCalendar:(id)p0 reuseIdentifier:(NSString *)p1;
@end

@interface TSQCalendarRowCell : TSQCalendarCell {
}
	-(id) backgroundImage;
	-(id) selectedBackgroundImage;
	-(id) todayBackgroundImage;
	-(id) notThisMonthBackgroundImage;
	-(id) beginningDate;
	-(void) setBeginningDate:(id)p0;
	-(bool) isBottomRow;
	-(void) setBottomRow:(bool)p0;
	-(void) selectColumnForDate:(id)p0;
	-(id) init;
	-(id) initWithCoder:(id)p0;
	-(id) initWithCalendar:(id)p0 reuseIdentifier:(NSString *)p1;
@end

@interface TSQTACalendarRowCell : TSQCalendarRowCell {
	int __monoObjectGCHandle;
}
	-(void) release;
	-(id) retain;
	-(void) dealloc;
	-(id) todayBackgroundImage;
	-(id) selectedBackgroundImage;
	-(id) notThisMonthBackgroundImage;
	-(id) backgroundImage;
	-(void) layoutViewsForColumnAtIndex:(unsigned int)p0 inRect:(CGRect)p1;
	-(bool) conformsToProtocol:(void *)p0;
	-(id) init;
@end
@implementation TSQTACalendarRowCell { } 
	-(void) release
	{
		monotouch_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return monotouch_retain_trampoline (self, _cmd);
	}

	-(void) dealloc
	{
		monotouch_unregister_object (self);
		monotouch_free_gchandle (self);
		[super dealloc];
	}

	-(id) todayBackgroundImage
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_4 (self, &managed_method, "TimesSquareiOSSample.TSQTACalendarRowCell, TimesSquareiOSSample", "get_TodayBackgroundImage");
	}

	-(id) selectedBackgroundImage
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_4 (self, &managed_method, "TimesSquareiOSSample.TSQTACalendarRowCell, TimesSquareiOSSample", "get_SelectedBackgroundImage");
	}

	-(id) notThisMonthBackgroundImage
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_4 (self, &managed_method, "TimesSquareiOSSample.TSQTACalendarRowCell, TimesSquareiOSSample", "get_NotThisMonthBackgroundImage");
	}

	-(id) backgroundImage
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_4 (self, &managed_method, "TimesSquareiOSSample.TSQTACalendarRowCell, TimesSquareiOSSample", "get_BackgroundImage");
	}

	-(void) layoutViewsForColumnAtIndex:(unsigned int)p0 inRect:(CGRect)p1
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_5 (self, &managed_method, p0, p1, "System.UInt32, mscorlib", "System.Drawing.RectangleF, monotouch", "TimesSquareiOSSample.TSQTACalendarRowCell, TimesSquareiOSSample", "LayoutViews");
	}

	-(bool) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_2 (self, &managed_method, p0, "System.IntPtr, mscorlib", "MonoTouch.Foundation.NSObject, monotouch", "InvokeConformsToProtocol");
	}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, &managed_method, "TimesSquareiOSSample.TSQTACalendarRowCell, TimesSquareiOSSample", ".ctor");
	}
@end

@interface TimesSquareiOSSample_TSQTAViewController : UIViewController {
	int __monoObjectGCHandle;
}
	-(void) release;
	-(id) retain;
	-(void) dealloc;
	-(void) loadView;
	-(bool) conformsToProtocol:(void *)p0;
	-(id) init;
@end
@implementation TimesSquareiOSSample_TSQTAViewController { } 
	-(void) release
	{
		monotouch_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return monotouch_retain_trampoline (self, _cmd);
	}

	-(void) dealloc
	{
		monotouch_unregister_object (self);
		monotouch_free_gchandle (self);
		[super dealloc];
	}

	-(void) loadView
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_6 (self, &managed_method, "TimesSquareiOSSample.TSQTAViewController, TimesSquareiOSSample", "LoadView");
	}

	-(bool) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_2 (self, &managed_method, p0, "System.IntPtr, mscorlib", "MonoTouch.Foundation.NSObject, monotouch", "InvokeConformsToProtocol");
	}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, &managed_method, "TimesSquareiOSSample.TSQTAViewController, TimesSquareiOSSample", ".ctor");
	}
@end

@interface __MonoMac_NSActionDispatcher : NSObject {
	int __monoObjectGCHandle;
}
	-(void) release;
	-(id) retain;
	-(void) dealloc;
	-(void) xamarinApplySelector;
	-(bool) conformsToProtocol:(void *)p0;
@end
@implementation __MonoMac_NSActionDispatcher { } 
	-(void) release
	{
		monotouch_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return monotouch_retain_trampoline (self, _cmd);
	}

	-(void) dealloc
	{
		monotouch_unregister_object (self);
		monotouch_free_gchandle (self);
		[super dealloc];
	}

	-(void) xamarinApplySelector
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_6 (self, &managed_method, "MonoTouch.Foundation.NSActionDispatcher, monotouch", "Apply");
	}

	-(bool) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_2 (self, &managed_method, p0, "System.IntPtr, mscorlib", "MonoTouch.Foundation.NSObject, monotouch", "InvokeConformsToProtocol");
	}
@end

@interface __NSObject_Disposer : NSObject {
	int __monoObjectGCHandle;
}
	-(void) release;
	-(id) retain;
	-(void) dealloc;
	+(void) drain:(id)p0;
	-(bool) conformsToProtocol:(void *)p0;
	-(id) init;
@end
@implementation __NSObject_Disposer { } 
	-(void) release
	{
		monotouch_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return monotouch_retain_trampoline (self, _cmd);
	}

	-(void) dealloc
	{
		monotouch_unregister_object (self);
		monotouch_free_gchandle (self);
		[super dealloc];
	}

	+(void) drain:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_7 (self, &managed_method, p0, "MonoTouch.Foundation.NSObject, monotouch", "MonoTouch.Foundation.NSObject+NSObject_Disposer, monotouch", "Drain");
	}

	-(bool) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_2 (self, &managed_method, p0, "System.IntPtr, mscorlib", "MonoTouch.Foundation.NSObject, monotouch", "InvokeConformsToProtocol");
	}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, &managed_method, "MonoTouch.Foundation.NSObject+NSObject_Disposer, monotouch", ".ctor");
	}
@end

@interface TSQCalendarMonthHeaderCell : TSQCalendarCell {
}
	-(NSArray *) headerLabels;
	-(void) setHeaderLabels:(NSArray *)p0;
	-(void) createHeaderLabels;
	-(id) init;
	-(id) initWithCoder:(id)p0;
	-(id) initWithCalendar:(id)p0 reuseIdentifier:(NSString *)p1;
@end

@protocol TSQCalendarViewDelegate/* <NSObject>*/
@end

@interface TimesSquare_iOS_TSQCalendarView__TSQCalendarViewDelegate : NSObject/*<TSQCalendarViewDelegate>*/ {
	int __monoObjectGCHandle;
}
	-(void) release;
	-(id) retain;
	-(void) dealloc;
	-(bool) calendarView:(id)p0 shouldSelectDate:(id)p1;
	-(void) calendarView:(id)p0 didSelectDate:(id)p1;
	-(bool) respondsToSelector:(SEL)p0;
	-(bool) conformsToProtocol:(void *)p0;
	-(id) init;
@end
@implementation TimesSquare_iOS_TSQCalendarView__TSQCalendarViewDelegate { } 
	-(void) release
	{
		monotouch_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return monotouch_retain_trampoline (self, _cmd);
	}

	-(void) dealloc
	{
		monotouch_unregister_object (self);
		monotouch_free_gchandle (self);
		[super dealloc];
	}

	-(bool) calendarView:(id)p0 shouldSelectDate:(id)p1
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_1 (self, &managed_method, p0, p1, "TimesSquare.iOS.TSQCalendarView, TimesSquare.iOS", "MonoTouch.Foundation.NSDate, monotouch", "TimesSquare.iOS.TSQCalendarView+_TSQCalendarViewDelegate, TimesSquare.iOS", "ShouldSelectDate");
	}

	-(void) calendarView:(id)p0 didSelectDate:(id)p1
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_8 (self, &managed_method, p0, p1, "TimesSquare.iOS.TSQCalendarView, TimesSquare.iOS", "MonoTouch.Foundation.NSDate, monotouch", "TimesSquare.iOS.TSQCalendarView+_TSQCalendarViewDelegate, TimesSquare.iOS", "DidSelectDate");
	}

	-(bool) respondsToSelector:(SEL)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_9 (self, &managed_method, p0, "MonoTouch.ObjCRuntime.Selector, monotouch", "TimesSquare.iOS.TSQCalendarView+_TSQCalendarViewDelegate, TimesSquare.iOS", "RespondsToSelector");
	}

	-(bool) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_2 (self, &managed_method, p0, "System.IntPtr, mscorlib", "MonoTouch.Foundation.NSObject, monotouch", "InvokeConformsToProtocol");
	}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, &managed_method, "TimesSquare.iOS.TSQCalendarView+_TSQCalendarViewDelegate, TimesSquare.iOS", ".ctor");
	}
@end

@interface TSQCalendarView : UIView {
}
	-(id) firstDate;
	-(void) setFirstDate:(id)p0;
	-(id) lastDate;
	-(void) setLastDate:(id)p0;
	-(id) selectedDate;
	-(void) setSelectedDate:(id)p0;
	-(id) calendar;
	-(void) setCalendar:(id)p0;
	-(id) delegate;
	-(void) setDelegate:(id)p0;
	-(bool) pinsHeaderToTop;
	-(void) setPinsHeaderToTop:(bool)p0;
	-(bool) pagingEnabled;
	-(void) setPagingEnabled:(bool)p0;
	-(UIEdgeInsets) contentInset;
	-(void) setContentInset:(UIEdgeInsets)p0;
	-(CGPoint) contentOffset;
	-(void) setContentOffset:(CGPoint)p0;
	-(Class) headerCellClass;
	-(void) setHeaderCellClass:(Class)p0;
	-(Class) rowCellClass;
	-(void) setRowCellClass:(Class)p0;
	-(void) scrollToDate:(id)p0 animated:(bool)p1;
	-(id) init;
	-(id) initWithCoder:(id)p0;
	-(id) initWithFrame:(CGRect)p0;
@end

	static MTClassMap __monotouch_class_map [] = {
		{"NSObject", "MonoTouch.Foundation.NSObject, monotouch", NULL },
		{"AppDelegate", "TimesSquareiOSSample.AppDelegate, TimesSquareiOSSample", NULL },
		{"UIResponder", "MonoTouch.UIKit.UIResponder, monotouch", NULL },
		{"UIView", "MonoTouch.UIKit.UIView, monotouch", NULL },
		{"UITableViewCell", "MonoTouch.UIKit.UITableViewCell, monotouch", NULL },
		{"TSQCalendarCell", "TimesSquare.iOS.TSQCalendarCell, TimesSquare.iOS", NULL },
		{"TSQCalendarRowCell", "TimesSquare.iOS.TSQCalendarRowCell, TimesSquare.iOS", NULL },
		{"TSQTACalendarRowCell", "TimesSquareiOSSample.TSQTACalendarRowCell, TimesSquareiOSSample", NULL },
		{"UIViewController", "MonoTouch.UIKit.UIViewController, monotouch", NULL },
		{"TimesSquareiOSSample_TSQTAViewController", "TimesSquareiOSSample.TSQTAViewController, TimesSquareiOSSample", NULL },
		{"NSArray", "MonoTouch.Foundation.NSArray, monotouch", NULL },
		{"NSCalendar", "MonoTouch.Foundation.NSCalendar, monotouch", NULL },
		{"NSCoder", "MonoTouch.Foundation.NSCoder, monotouch", NULL },
		{"NSDate", "MonoTouch.Foundation.NSDate, monotouch", NULL },
		{"NSString", "MonoTouch.Foundation.NSString, monotouch", NULL },
		{"__MonoMac_NSActionDispatcher", "MonoTouch.Foundation.NSActionDispatcher, monotouch", NULL },
		{"NSAutoreleasePool", "MonoTouch.Foundation.NSAutoreleasePool, monotouch", NULL },
		{"UIAlertView", "MonoTouch.UIKit.UIAlertView, monotouch", NULL },
		{"UIApplication", "MonoTouch.UIKit.UIApplication, monotouch", NULL },
		{"UIBarItem", "MonoTouch.UIKit.UIBarItem, monotouch", NULL },
		{"UIColor", "MonoTouch.UIKit.UIColor, monotouch", NULL },
		{"UIImage", "MonoTouch.UIKit.UIImage, monotouch", NULL },
		{"UIScreen", "MonoTouch.UIKit.UIScreen, monotouch", NULL },
		{"UIWindow", "MonoTouch.UIKit.UIWindow, monotouch", NULL },
		{"UILabel", "MonoTouch.UIKit.UILabel, monotouch", NULL },
		{"UINavigationItem", "MonoTouch.UIKit.UINavigationItem, monotouch", NULL },
		{"UITabBarController", "MonoTouch.UIKit.UITabBarController, monotouch", NULL },
		{"UITabBarItem", "MonoTouch.UIKit.UITabBarItem, monotouch", NULL },
		{"NSException", "MonoTouch.Foundation.NSException, monotouch", NULL },
		{"NSDictionary", "MonoTouch.Foundation.NSDictionary, monotouch", NULL },
		{"__NSObject_Disposer", "MonoTouch.Foundation.NSObject+NSObject_Disposer, monotouch", NULL },
		{"TSQCalendarMonthHeaderCell", "TimesSquare.iOS.TSQCalendarMonthHeaderCell, TimesSquare.iOS", NULL },
		{"TimesSquare_iOS_TSQCalendarView__TSQCalendarViewDelegate", "TimesSquare.iOS.TSQCalendarView+_TSQCalendarViewDelegate, TimesSquare.iOS", NULL },
		{"TSQCalendarView", "TimesSquare.iOS.TSQCalendarView, TimesSquare.iOS", NULL },
		{ NULL, NULL, NULL },
	};


void monotouch_create_classes () {
	__monotouch_class_map [0].handle = objc_getClass ("NSObject");
	__monotouch_class_map [1].handle = [AppDelegate class];
	__monotouch_class_map [2].handle = objc_getClass ("UIResponder");
	__monotouch_class_map [3].handle = objc_getClass ("UIView");
	__monotouch_class_map [4].handle = objc_getClass ("UITableViewCell");
	__monotouch_class_map [5].handle = [TSQCalendarCell class];
	__monotouch_class_map [6].handle = [TSQCalendarRowCell class];
	__monotouch_class_map [7].handle = [TSQTACalendarRowCell class];
	__monotouch_class_map [8].handle = objc_getClass ("UIViewController");
	__monotouch_class_map [9].handle = [TimesSquareiOSSample_TSQTAViewController class];
	__monotouch_class_map [10].handle = objc_getClass ("NSArray");
	__monotouch_class_map [11].handle = objc_getClass ("NSCalendar");
	__monotouch_class_map [12].handle = objc_getClass ("NSCoder");
	__monotouch_class_map [13].handle = objc_getClass ("NSDate");
	__monotouch_class_map [14].handle = objc_getClass ("NSString");
	__monotouch_class_map [15].handle = objc_getClass ("__MonoMac_NSActionDispatcher");
	__monotouch_class_map [16].handle = objc_getClass ("NSAutoreleasePool");
	__monotouch_class_map [17].handle = objc_getClass ("UIAlertView");
	__monotouch_class_map [18].handle = objc_getClass ("UIApplication");
	__monotouch_class_map [19].handle = objc_getClass ("UIBarItem");
	__monotouch_class_map [20].handle = objc_getClass ("UIColor");
	__monotouch_class_map [21].handle = objc_getClass ("UIImage");
	__monotouch_class_map [22].handle = objc_getClass ("UIScreen");
	__monotouch_class_map [23].handle = objc_getClass ("UIWindow");
	__monotouch_class_map [24].handle = objc_getClass ("UILabel");
	__monotouch_class_map [25].handle = objc_getClass ("UINavigationItem");
	__monotouch_class_map [26].handle = objc_getClass ("UITabBarController");
	__monotouch_class_map [27].handle = objc_getClass ("UITabBarItem");
	__monotouch_class_map [28].handle = objc_getClass ("NSException");
	__monotouch_class_map [29].handle = objc_getClass ("NSDictionary");
	__monotouch_class_map [30].handle = objc_getClass ("__NSObject_Disposer");
	__monotouch_class_map [31].handle = [TSQCalendarMonthHeaderCell class];
	__monotouch_class_map [32].handle = [TimesSquare_iOS_TSQCalendarView__TSQCalendarViewDelegate class];
	__monotouch_class_map [33].handle = [TSQCalendarView class];
	monotouch_setup_classmap (__monotouch_class_map, 34);
}

