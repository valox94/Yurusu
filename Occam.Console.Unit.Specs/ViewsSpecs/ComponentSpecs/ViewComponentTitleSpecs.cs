using FakeItEasy;
using Occam.Console.Views.Components;
using Xunit;
namespace Occam.Console.Unit.Specs.ViewsSpecs.ComponentSpecs;

public class ViewComponentTitleSpecs
{
        public class WhenTitleIsSet
        {
            [Fact]
            public void should_show_empty_char_before_title()
            {
                var console = A.Fake<IGameConsole>();
        
                var viewComponent = new ViewComponentTitle(console);
        
                viewComponent.SetValue("Title");
                viewComponent.SetMaxLength(8);
                viewComponent.Render();
        
                A.CallTo(() => console.WriteAt(1, 0,' ')).MustHaveHappened(); 
            }
            [Fact]
            public void should_show_title_chars_starting_at_left_2()
            {
                var console = A.Fake<IGameConsole>();
        
                var viewComponent = new ViewComponentTitle(console);
        
                viewComponent.SetValue("Title");
                viewComponent.SetMaxLength(8);

                viewComponent.Render();
        
                A.CallTo(() => console.WriteAt(2, 0,'T')).MustHaveHappened(); 
                A.CallTo(() => console.WriteAt(3, 0,'i')).MustHaveHappened(); 
                A.CallTo(() => console.WriteAt(4, 0,'t')).MustHaveHappened(); 
                A.CallTo(() => console.WriteAt(5, 0,'l')).MustHaveHappened(); 
                A.CallTo(() => console.WriteAt(6, 0,'e')).MustHaveHappened(); 
            }
            [Fact]
            public void should_show_empty_char_after_title()
            {
                var console = A.Fake<IGameConsole>();
        
                var viewComponent = new ViewComponentTitle(console);
        
                viewComponent.SetValue("Title");
                viewComponent.SetMaxLength(8);

                viewComponent.Render();
        
                A.CallTo(() => console.WriteAt(7, 0,' ')).MustHaveHappened(); 
            }
        
            public class WhenTitleIsGreaterThanMaxLength
            {
                [Fact]
                public void should_show_title_as_much_title_as_possible()
                {
                    var console = A.Fake<IGameConsole>();
                
                    var viewComponent = new ViewComponentTitle(console);
                
                    viewComponent.SetValue("Long Title");
                    viewComponent.SetMaxLength(8);

                    viewComponent.Render();
                
                    A.CallTo(() => console.WriteAt(1, 0,' ')).MustHaveHappened(); 
                    A.CallTo(() => console.WriteAt(2, 0,'L')).MustHaveHappened(); 
                    A.CallTo(() => console.WriteAt(3, 0,'o')).MustHaveHappened(); 
                    A.CallTo(() => console.WriteAt(4, 0,'n')).MustHaveHappened(); 
                    A.CallTo(() => console.WriteAt(5, 0,'g')).MustHaveHappened(); 
                    A.CallTo(() => console.WriteAt(6, 0,' ')).MustHaveHappened(); 
                    
                }
                
                [Fact]
                public void should_not_show_any_title_chars_that_may_obscure_border_corner()
                {
                    var console = A.Fake<IGameConsole>();
                
                    var viewComponent = new ViewComponentTitle(console);
                
                    viewComponent.SetValue("Long-Title");
                    viewComponent.SetMaxLength(8);
                
                    viewComponent.Render();
                
                    A.CallTo(() => console.WriteAt(8, 0, ' ')).MustNotHaveHappened(); 
                }
                
                [Fact]
                public void should_not_show_orphaned_empty_char_at_end_of_title()
                {
                    var console = A.Fake<IGameConsole>();
                
                    var viewComponent = new ViewComponentTitle(console);
                
                    viewComponent.SetValue("Long Title");
                    viewComponent.SetMaxLength(8);
                
                    viewComponent.Render();
                
                    A.CallTo(() => console.WriteAt(8, 0, ' ')).MustNotHaveHappened(); 
                }
            }
        }
}