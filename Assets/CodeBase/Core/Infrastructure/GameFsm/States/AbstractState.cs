﻿using System.Collections;
using System.Collections.Generic;

namespace Core.Infrastructure.GameFsm.States
{
    public abstract class AbstractState : IState
    {
        protected readonly IGameFsm GameFsm;
        private readonly List<ILink> m_Links = new();
        
        /// <summary>
        /// The name of the state used for debugging purposes
        /// </summary>
        public virtual string Name { get; set; }
        
        protected AbstractState(IGameFsm gameFsm)
        {
            GameFsm = gameFsm;
        }

        public virtual void Enter()
        {
            
        }

        public abstract IEnumerator Execute();

        public virtual void AddLink(ILink link)
        {
            if (!m_Links.Contains(link))
            {
                m_Links.Add(link);
            }
        }

        public virtual void RemoveLink(ILink link)
        {
            if (m_Links.Contains(link))
            {
                m_Links.Remove(link);
            }
        }

        public virtual void RemoveAllLinks()
        {
            m_Links.Clear();
        }

        public virtual bool ValidateLinks(out IState nextState)
        {
            if (m_Links != null && m_Links.Count > 0)
            {
                foreach (var link in m_Links)
                {
                    var result = link.Validate(out nextState);
                    if (result)
                    {
                        return true;
                    }
                }
            }

            //default
            nextState = null;
            return false;
        }

        public void EnableLinks()
        {
            foreach (var link in m_Links)
            {
                link.Enable();
            }
        }

        public void DisableLinks()
        {
            foreach (var link in m_Links)
            {
                link.Disable();
            }
        }

        public virtual void Exit()
        {
            
        }
    }
}